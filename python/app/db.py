import motor.motor_asyncio
import pandas as pd
import logging
import os
from .models.models import ModelPrediction, Prediction
from .utils import load_model_details

client = motor.motor_asyncio.AsyncIOMotorClient("mongodb://db:27017")
tableName = "predictions"

def getColl():
    name = (load_model_details().model_pipeline_name) + "_" + (load_model_details().model_name)
    db = client[name]
    return db[tableName]

async def save_to_db(input: list, prediction: Prediction) -> None:
    modelPrediction = ModelPrediction(input=input, prediction=dict(prediction))
    coll = getColl()
    errors = await coll.insert_one(dict(modelPrediction))
    
    if errors:
        logging.info(f"Error: {str(errors)}")
        return 
    
    logging.info("Saved prediction")


async def load_last_predictions_from_db() -> pd.DataFrame:
    coll = getColl()
    last_predictions = coll.find()
    last_predictions = await last_predictions.to_list(None)
    input_data = [prediction["input"] for prediction in last_predictions]
    predictions = [prediction["prediction"].get("prediction") for prediction in last_predictions]
    for data, prediction in zip(input_data, predictions):
        data.append(prediction)

    df = pd.DataFrame(input_data)
    return df


async def getConfiguration():
    host = "host.docker.internal"
    name = "MLOps"
    client = motor.motor_asyncio.AsyncIOMotorClient("mongodb://{host}:27017")
    db = client[name]
    coll = db["Config"]

    results = coll.find()