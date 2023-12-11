// Jenkinsfile (Declarative Pipeline)
pipeline {
    agent {
        label 'jenkinsSrv'
    }

    environment {
        dockerImage = "dotnet"
        dockerImageFile = "${dockerImage}.tar"
        remote_username = "vagrant"
        remote_password = "vagrant"
    }

    stages {
        stage('Checkout') {
            agent {
                label 'jenkinsSrv'
            }
            steps {
                checkout scm
            }
        }

        stage('Docker Build') {
            agent {
                label 'jenkinsSrv'
            }
            steps {
                script {
                    sh "docker build -t ${dockerImage} ."
                }
            }
        }

        stage('Export and transfer Docker image') {
            agent {
                label 'jenkinsSrv'
            }
            steps {
                script {
                    sh "docker save -o ${dockerImageFile} ${dockerImage}"
                    sh "scp ${dockerImageFile} ${remote_username}@${remote_password}:/vagrant/"
                }
            }
        }

        stage('Load Docker image on webSrv node') {
            agent {
                label 'webSrv'
            }
            steps {
                script {
                    sh "docker image load -i /vagrant/${dockerImageFile}"
                }
            }

        }

        stage('Deploy Docker build on Webserver agent') {
            agent {
                label 'webSrv'
            }
            steps {
                script {
                    def containerName = "mijn-dotnet-app-container"
                    def port = "3000"

                    sh "docker run -p ${port}:80 --rm --name ${containerName} ${dockerImage}" 
                }
            }
        }

    }

}
