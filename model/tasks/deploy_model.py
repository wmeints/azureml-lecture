"""
Deploy model
=============
This tasks helps you deploy models to an Azure Container Instance.
It uses the scoring script from the project package.

Feel free to modify this script to your needs.
Make sure you modify the customer_churn/score.py as well.

Parameters
-----------
- name: The name of the webservice
- model: The name of the model to deploy to production
"""

import click
from pathlib import Path
from azureml.core import Workspace
from azureml.core.model import Model, InferenceConfig
from azureml.core.webservice import AciWebservice, Webservice

@click.command()
@click.option("--name", help="The name of the webservice")
@click.option("--model", help="The name of the model to deploy")
def main(name, model):
    workspace = Workspace.from_config()
    model = Model(workspace, name=model)

    root_folder = Path(__file__).parent.parent

    deployment_config = AciWebservice.deploy_configuration(cpu_cores=1, memory_gb=1)

    inference_config = InferenceConfig(
        entry_script='customer_churn/score.py', 
        source_directory=root_folder
    )

    webservice = Model.deploy(
        workspace=workspace, 
        name=name, 
        models=[model], 
        deployment_config=deployment_config, 
        inference_config=inference_config
    )

    webservice.wait_for_deployment(show_output=True)

if __name__ == '__main__':
    main()