Jenkinsfile (Declarative Pipeline)
pipeline {
    agent any

    stages {
        stage('Checkout') {
            steps {
                checkout scm
            }
        }

        stage('Build') {
            steps {
                script {
                    def dotnetCommand = "dotnet"
                    def buildCommand = "${dotnetCommand} build"
                    
                    sh script: buildCommand, returnStatus: true
                }
            }
        }

        stage('Docker Build') {
            steps {
                script {
                    def dockerImage = "mijn-dotnet-app"
                    def dockerfilePath = "./Dockerfile"

                    sh "docker build -t ${dockerImage} -f ${dockerfilePath} ."
                }
            }
        }

        stage('Run in Docker') {
            steps {
                script {
                    def dockerImage = "mijn-dotnet-app"
                    def containerName = "mijn-dotnet-app-container"

                    sh "docker run --rm --name ${containerName} ${dockerImage}"
                }
            }
        }
    }

    post {
        always {
            script {
                def containerName = "mijn-dotnet-app-container"
                
                sh "docker rm -f ${containerName}"
            }
        }
    }
}
