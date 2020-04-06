"""
Prepare dataset
================
This task prepares the dataset for use by the application and this model.
It cleans up missing values and converts data in the columns to the proper
types.

Parameters:
------------
- input_filename: The input filename to read from
- output_folder: The output folder where the processed data should be stored
"""

import os
from pathlib import Path
import click
import pandas as pd


TRISTATE_COLUMNS = [
    'PhoneService',
    'MultipleLines',
    'OnlineSecurity',
    'OnlineBackup',
    'DeviceProtection',
    'TechSupport',
    'StreamingTV',
    'StreamingMovies',
]


def map_contract_type(value):
    if value == 'Month-to-month':
        return 'Monthly'
    if value == 'One year':
        return 'OneYear'
    if value == 'Two year':
        return 'TwoYear'


def map_tristate(value):
    if value == 'Yes':
        return 'Yes'
    elif value == 'No':
        return 'No'
    else:
        return 'NotApplicable'


def map_payment_method(value):
    if value == 'Electronic check':
        return 'ElectronicCheck'
    elif value == 'Mailed check':
        return 'MailedCheck'
    elif value == 'Bank transfer (automatic)':
        return 'BankTransfer'
    elif value == 'Credit card (automatic)':
        return 'CreditCard'


def map_connection_type(value):
    if value == 'DSL':
        return 'DSL'
    elif value == 'Fiber optic':
        return 'FiberOptic'
    else:
        return 'None'


@click.command()
@click.option('--input_file', help='The CSV file to read the raw data from')
@click.option('--output_folder', help='The output folder to store the data')
def main(input_file, output_folder):
    df_churn = pd.read_csv(input_file, na_values=[' '])

    df_churn['Contract'] = df_churn['Contract'].apply(map_contract_type)
    df_churn['PaymentMethod'] = df_churn['PaymentMethod'].apply(map_payment_method)
    df_churn['InternetService'] = df_churn['InternetService'].apply(map_connection_type)
    df_churn['Partner'] = df_churn['Partner'].apply(lambda x: 1 if x == 'Yes' else 0)
    df_churn['Dependents'] = df_churn['Dependents'].apply(lambda x: 1 if x == 'Yes' else 0)
    df_churn['PaperlessBilling'] = df_churn['PaperlessBilling'].apply(lambda x: 1 if x == 'Yes' else 0)
    df_churn['Partner'] = df_churn['Partner'].apply(lambda x: 1 if x == 'Yes' else 0)
    df_churn['Churn'] = df_churn['Churn'].apply(lambda x: 1 if x == 'Yes' else 0)
    
    for tristate_column in TRISTATE_COLUMNS:
        df_churn[tristate_column] = df_churn[tristate_column].apply(map_tristate)

    df_churn.columns = ['Id', 'Gender', 'SeniorCitizen', 'Partner', 'Dependents',
       'Tenure', 'PhoneService', 'MultipleLines', 'InternetService',
       'OnlineSecurity', 'OnlineBackup', 'DeviceProtection', 'TechSupport',
       'StreamingTV', 'StreamingMovies', 'Contract', 'PaperlessBilling',
       'PaymentMethod', 'MonthlyCharges', 'TotalCharges', 'Churn']

    df_app = df_churn.drop(['Churn'], axis=1)

    app_data_folder = Path(output_folder, 'app')
    model_data_folder = Path(output_folder, 'model')

    app_data_folder.mkdir(parents=True, exist_ok=True)
    model_data_folder.mkdir(parents=True, exist_ok=True)

    df_churn.to_csv(Path(model_data_folder, 'customer-churn-cleaned.csv'), index=False)
    df_app.to_csv(Path(app_data_folder, 'customer-churn-cleaned.csv'), index=False)


if __name__ == '__main__':
    main()
