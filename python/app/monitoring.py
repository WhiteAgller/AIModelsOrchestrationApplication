import logging
import pandas as pd
import csv
from fastapi.responses import JSONResponse, HTMLResponse
from evidently.metric_preset import DataDriftPreset, ClassificationPreset, RegressionPreset
from evidently import ColumnMapping
from evidently.report import Report
from .utils import load_test_data, load_train_data, load_model
from .db import load_last_predictions_from_db
from .models.models import ModelType


async def load_predicted_data() -> pd.DataFrame:
    df = await load_last_predictions_from_db()
    df = await transform_dataframe(df)
    df = df.apply(pd.to_numeric, errors='coerce')
    return df


async def transform_dataframe(df: pd.DataFrame) -> pd.DataFrame:
    file_path = 'test_data.csv'
    with open(file_path, 'r') as csv_file:    
        csv_reader = csv.reader(csv_file, delimiter=',')
        list_of_column_names = next(csv_reader)
        list_of_column_names[-1] = "prediction"
        df.columns = list_of_column_names
    return df


def load_train_data_transformed() -> pd.DataFrame:
    df = load_train_data()
    df = change_last_column_name(df)
    return df


async def measure_data_drift() -> str:
    dasboard_name = "reports/data_drift.html"
    data_drift_report = Report(metrics=[
    DataDriftPreset()
    ])
    reference_data = load_train_data_transformed()
    current_data = await load_predicted_data()
    # current_data = load_test_data()

    numerical_features, categorical_features = get_numerical_and_categorical_columns(reference_data)

    column_mapping = ColumnMapping()
    column_mapping.categorical_features = numerical_features
    column_mapping.numerical_features = categorical_features

    data_drift_report.run(reference_data=reference_data, current_data=current_data, column_mapping=column_mapping)
    data_drift_report.save_html(dasboard_name)

    logging.info(f"Dashboard saved to {dasboard_name}")
    
    f = open(dasboard_name, "r")
    content = f.read()

    return HTMLResponse(content=content, status_code=200)


async def measure_performance(type: ModelType, json: bool) -> str:
    dasboard_name = "reports/performance.html"
    if(type.Klasifikiace):
        performance_report = Report(metrics=[
        ClassificationPreset(),
        ])
    elif(type.Regrese):
        performance_report = Report(metrics=[
        RegressionPreset(),
        ])    
    reference_data = load_train_data_transformed()
    current_data = await load_predicted_data()   
    # current_data = load_test_data()

    classifier = load_model()

    target= "prediction"
    numerical_features, categorical_features = get_numerical_and_categorical_columns(reference_data)

    y_train, y_test = reference_data[target], current_data[target]

    X_train = reference_data.drop(columns=[target], axis=1)
    X_test =  current_data.drop(columns=[target], axis=1)

    pred_train = classifier.predict(X_train)
    pred_test = classifier.predict(X_test)

    X_train = X_train.assign(target=y_train, prediction=pred_train)
    X_test = X_test.assign(target=y_test, prediction=pred_test)

    column_mapping = ColumnMapping()
    column_mapping.target = 'target'
    column_mapping.prediction = 'prediction'
    
    performance_report.run(reference_data=X_train, current_data=X_test, column_mapping=column_mapping)
    performance_report.save_html(dasboard_name)

    logging.info(f"Dashboard saved to {dasboard_name}")

    if json:
        return JSONResponse(content=performance_report.json(), status_code=200)
    
    f = open(dasboard_name, "r")
    content = f.read()    
    return HTMLResponse(content=content, status_code=200)

def change_last_column_name(df: pd.DataFrame) -> pd.DataFrame:
        current_columns = df.columns.tolist()
        last_column_name = current_columns[-1]
        df = df.rename(columns={last_column_name: "prediction"})
        return df


def get_numerical_and_categorical_columns(df: pd.DataFrame) -> tuple:
    numeric_values = df.loc[:, df.dtypes != object].columns.tolist()
    string_values = df.loc[:, df.dtypes == object].columns.tolist()
    return numeric_values, string_values 


def get_last_column_name(df: pd.DataFrame) -> str:
    current_columns = df.columns.tolist()
    return current_columns[-1]