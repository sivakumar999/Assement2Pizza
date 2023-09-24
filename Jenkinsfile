pipeline {
    agent any

    environment {
        PATH = "C:\\Windows\\System32;C:\\Program Files\\dotnet;C:\\Program Files\\Docker"
        AZURE_CREDENTIALS = credentials('azure-cred') 
        DOCKER_REGISTRY = 'docker.io'
        DOCKER_REPO = 'tulasivenkatasivakumar/joespizza'

        AZURE_VM_IP = '20.65.243.182'
    }

    stages {
        stage('Checkout') {
            steps {
                checkout scm
            }
        }

        stage('Build and Test') {
            steps {
                script {
                    bat 'dotnet build'
                    bat 'dotnet test'
                }
            }
        }

        stage('Dockerize') {
            steps {
                script {
                    def dockerImage = docker.build("${DOCKER_REGISTRY}/${DOCKER_REPO}:${env.BUILD_NUMBER}")
                    docker.withRegistry('', 'docker-cred') {
                        dockerImage.push()
                    }
                }
            }
        }

        stage('Deploy to Azure VM') {
            steps {
                script {
                    azureDeploy(credentialsId: 'azure-cred',
                                azureCredentialsVersion: '2.0',
                                resourceGroup: 'RG1',
                                location: 'South Central US',
                                templateFilePath: 'azuredeploy.json',
                                parametersFilePath: 'azuredeploy.parameters.json',
                                deploymentName: 'deploy',
                                waitForCompletion: true)
                }
            }
        }
    }

    post {
    always {
        // Clean up resources if needed
        echo "Always execute this block of code"

        // Add your cleanup tasks here
        // For example, deleting temporary files, stopping services, etc.
    }

    success {
        // Actions to perform when the pipeline is successful
        echo "Pipeline executed successfully"
    }

    failure {
        // Actions to perform when the pipeline fails
        echo "Pipeline failed"

        // You can add additional actions for failure scenarios here
    }

    unstable {
        // Actions to perform when the pipeline is unstable
        echo "Pipeline is unstable"

        // You can add additional actions for unstable scenarios here
    }

    changed {
        // Actions to perform when the pipeline state changes (e.g., from success to failure)
        echo "Pipeline state changed"
    }
}

}
