import uvicorn
from fastapi import FastAPI
from .monitoring import measure_data_drift, measure_performance
from .models.models import Prediction, PipelineIdDto, ModelType
from .data_service import get_train_data, get_test_data, get_model, get_model_detail
from .predict import make_prediction
from .exception import check_if_model_is_deployed

app = FastAPI()

@app.post("/predict")
async def predict(input: list) -> Prediction:
    check_if_model_is_deployed()
    return await make_prediction(input)
    

@app.get("/data-drift")
async def data_drift_monitoring():
    check_if_model_is_deployed()
    return await measure_data_drift()
    

@app.get("/performance")
async def performace_monitoring(type: ModelType, json: bool):
    check_if_model_is_deployed()
    return await measure_performance(type, json)
    

@app.post("/deployModel")
async def deployModel(input: PipelineIdDto):
    get_model_detail(input.modelName, input.modelVersion, input.pipelineName)
    get_test_data(input.testData)
    get_train_data(input.trainData)
    get_model(input.model)

    return {"Deployment": "Ok"}

if __name__ == '__main__':
    uvicorn.run(app, host='0.0.0.0', port=8000, timeout_keep_alive=1000)
    