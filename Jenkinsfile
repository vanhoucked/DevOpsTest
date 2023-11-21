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
/*              def dockerfile = "./Dockerfile"
                def dockerImage = "mijn-dotnet-app" */

                sh "ls -l"
                sh 'docker build -f ./Dockerfile -t mijn-dotnet-app .'
                }
        }

        stage('Run in Docker') {
            steps {
/*                 def dockerImage = "mijn-dotnet-app"
                def containerName = "mijn-dotnet-app-container"
                def port = "3000" */

                sh "docker run -p 3000:80 --rm --name dotnet-container mijn-dotnet-app"
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
