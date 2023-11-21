// Jenkinsfile (Declarative Pipeline)
pipeline {
    agent any

    stages {
        stage('Checkout') {
            steps {
                checkout scm
            }
        }

/*         stage('Build') {
            steps {
                script {
                    def dotnetCommand = "dotnet"
                    def buildCommand = "${dotnetCommand} build"
                    
                    sh script: buildCommand, returnStatus: true
                }
            }
        } */

        stage('Docker Build') {
            steps {
                script {
/*                     def dockerfile = "./Dockerfile"
                    def dockerImage = "mijn-dotnet-app" */

                    sh "docker build -f ./Dockerfile -t mijn-dotnet-app ."
                }
            }
        }

        stage('Run in Docker') {
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

    post {
        always {
            script {
                def containerName = "mijn-dotnet-app-container"
                
                sh "docker rm -f ${containerName}"
            }
        }
    }
}
