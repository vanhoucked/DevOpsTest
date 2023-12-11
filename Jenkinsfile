// Jenkinsfile (Declarative Pipeline)
pipeline {
    agent any

    stages {
        stage('Checkout') {
            steps {
                checkout scm
            }
        }

        stage('Docker Build') {
            steps {
                script {
                    def dockerImage = "mijn-dotnet-app"

                    sh "docker build -t ${dockerImage} ."
                }
            }
        }

        stage('Run in Docker') {
            agent {
                label "webSrv"
            }
            steps {
                script {
                def dockerImage = "mijn-dotnet-app"
                def containerName = "mijn-dotnet-app-container"
                def port = "3000"

                sh "docker run -p ${port}:80 --rm --name ${containerName} ${dockerImage}"
                }
            }
        }
    }

}
