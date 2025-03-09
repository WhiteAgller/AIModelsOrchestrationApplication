import pandas as pd
import cloudpickle
import json
from .models.models import ModelVersion


def load_train_data() -> pd.DataFrame:
    train_file = "train_data.csv"
    return pd.read_csv(train_file)


def load_test_data() -> pd.DataFrame:
    test_file = "test_data.csv"
    return pd.read_csv(test_file)
    
    
def load_model() -> any:
    with open("model.pkl", 'rb') as model:
        return cloudpickle.load(model)
    

def load_model_details() -> ModelVersion:
    with open('model.json', 'r') as model_file:
        data = json.load(model_file)
        return ModelVersion(model_name=data["modelName"], model_version=data["modelVersion"], model_pipeline_name=data["modelPipelineName"])
