from pydantic import BaseModel
from enum import Enum

class PredictInput(BaseModel):
    input: list = []

class Prediction(BaseModel):
    prediction: int = 0
    model_name: str = ""
    model_version: str = ""
    
    class Config:
        allow_population_by_field_name = True


class ModelPrediction(BaseModel):
    input: list = []
    prediction: dict = {}

    class Config:
        allow_population_by_field_name = True


class PredictionResult(BaseModel):
    prediction: Prediction
    model: str
    version: str

class ModelVersion(BaseModel):
    model_name = ""
    model_version = ""
    model_pipeline_name = ""

class LatestModel(BaseModel):
    ModelName: str = ""
    ModelVersion: str = ""

class PipelineIdDto(BaseModel):
    # pipelineId: str = ""
    pipelineName: str = ""
    model: str = "",
    testData: str = "",
    trainData: str = "",
    modelName: str = "",
    modelVersion: str = ""

    

class ModelType(str, Enum):
    Regrese = "Regrese"
    Klasifikace = "Klasifikace"
