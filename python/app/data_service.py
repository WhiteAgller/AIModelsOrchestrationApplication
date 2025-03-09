import pandas as pd
import requests
import base64
import cloudpickle
import json

from .models.models import LatestModel

host="host.docker.internal"
port="44316"


def get_test_data(test_data: str) -> pd.DataFrame:
    string_content = base64.b64decode(test_data).decode('utf-8')
    with open("test_data.csv", 'w+') as file:
        file.write(string_content)
    return pd.read_csv("test_data.csv", sep=",")


def get_train_data(train_data: str) -> pd.DataFrame:
    string_content = base64.b64decode(train_data).decode('utf-8')
    with open("train_data.csv", 'w+') as file:
        file.write(string_content)
    return pd.read_csv("train_data.csv", sep=",")


def get_model(model: str) -> any:
    string_content = base64.b64decode(model)
    with open("model.pkl", 'wb') as fw:
        fw.write(string_content)
        
    with open("model.pkl", 'rb') as pickle_file:
         return cloudpickle.load(pickle_file)
    

def get_model_detail(model_name: str, model_version: str, pipelineName: str) -> any:
    model_json = {
        "modelName": model_name,
        "modelVersion": model_version,
        "modelPipelineName": pipelineName
    }

    with open("model.json", "w") as outfile:
        json.dump(model_json, outfile)
        return model_json