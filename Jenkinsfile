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
        remote_ip = "172.16.128.102"
        containerName = "mijn-dotnet-app-container"
        port = "3000"
    }

    stages {
        stage('Checkout') {
            steps {
                checkout scm
            }
        }

        stage('Docker Build') {
            steps {
                script {
                    sh "docker build -t ${dockerImage} ."
                }
            }
        }

        stage('Export and transfer Docker image') {
            steps {
                script {
                    sh "docker save -o ${dockerImageFile} ${dockerImage}"
                    sh "sshpass -p ${remote_password} scp -o StrictHostKeyChecking=no ${dockerImageFile} ${remote_username}@${remote_ip}:/vagrant/"
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
                    sh "docker run -p ${port}:80 --rm --name ${containerName} ${dockerImage}" 
                }
            }
        }

    }

    post {
        always {
            script {
                sh "rm -f ${dockerImageFile}"
                sh "docker rm ${containerName}"
            }
        }
    }

}
