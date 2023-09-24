pipeline {
    agent any

    environment {
        PATH = "C:\\Windows\\System32;C:\\Program Files\\dotnet"
        AZURE_CREDENTIALS = credentials('azure-cred') 
        DOCKER_REGISTRY = 'docker.io'
        DOCKER_REPO = 'tulasivenkatasivakumar/joespizza'

        AZURE_VM_IP = '20.65.243.182'
    }

    tools {
        // Define Docker installation
        docker 'dockerInstallation'
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
            echo "Always execute this block of code"
        }

        success {
            echo "Pipeline executed successfully"
        }

        failure {
            echo "Pipeline failed"
        }

        unstable {
            echo "Pipeline is unstable"
        }

        changed {
            echo "Pipeline state changed"
        }
    }
}
