from .utils import load_model, load_model_details
from .models.models import Prediction, PredictInput
from .db import save_to_db


async def make_prediction(input: list):
    prediction = await predict(input)
    await save_to_db(input, prediction)
    return prediction


async def predict(input: list) -> Prediction:
    classifier = load_model()
    default_prediction = classifier.predict([input])
    details = load_model_details()
    return Prediction(prediction=default_prediction[0], model_name=details.model_name, model_version=details.model_version)
