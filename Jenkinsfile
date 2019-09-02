pipeline {
    agent {
      node {
        label 'dockerdotnet'
              //customWorkspace '/some/other/path'
      }
    }
          
    stages {
      stage('CheckOut') {
        steps {
          checkout scm
          sh 'ls -la'
          sh "echo MINHA BRANCH É ${GIT_BRANCH}"
        }
      }
      
      stage('Testes') {
        steps {
          sh "echo executar testes"  
            
        }
      }
      
      stage('Analise codigo') {
        steps {
          sh 'dotnet-sonarscanner begin /k:"SME-Pedagogico-Gestao-DEV" /d:sonar.host.url="http://automation.educacao.intranet:9000" /d:sonar.login="b508b5e2675012bb5077f4dd5e3a8854a4472b77"'
          sh 'dotnet build'
          sh 'dotnet-sonarscanner end /d:sonar.login="b508b5e2675012bb5077f4dd5e3a8854a4472b77"'
        }
      }
     
      
      stage('Build') {
        steps {
          //sh 'dotnet-sonarscanner begin /k:"SME-Pedagogico-API-DEV" /d:sonar.host.url="http://automation.educacao.intranet:9000" /d:sonar.login="b5c1bda4c6e9a4cc414d37f3dd9e163cd6e54f92"'
          sh 'dotnet build'
          //sh 'dotnet-sonarscanner end /d:sonar.login="d5d0485ee11059d5a9110a9dcce00cb9a098d10b"'
        }
      }
      
      //stage('Deploy para hom') {
      //      agent any
      //      when {
      //          branch 'homologacao' 
      //      }
      //      steps {
                //sh './jenkins/scripts/deliver-for-development.sh'
      //          sh "echo entregar homologação"
      //          input message: 'entregar homologacao??', ok: 'aprovar'
                //sh './jenkins/scripts/kill.sh'
      //      }
      //}
      
      
}


    
post {
        always {
            echo 'One way or another, I have finished'
            deleteDir() /* clean up our workspace */
        }
        success {
            withCredentials([string(credentialsId: 'webhook-teams-gestao', variable: 'WHgestao-Teams')]) {
              echo ' Sucesso !'
              office365ConnectorSend color: '008000', message: "O Build ${BUILD_DISPLAY_NAME} - Esta ok !!!  <${env.BUILD_URL}> ", status: 'SUCESSO', webhookUrl: '$WHgestao-Teams'
             
            }
            telegramSend("${JOB_NAME}...O Build ${BUILD_DISPLAY_NAME} - Esta ok !!!  <${env.BUILD_URL}> ")
        }
        unstable {
            withCredentials([string(credentialsId: 'webhook-teams-gestao', variable: 'WHgestao-Teams')]) {
              echo ' Instavel !!! :/'
              office365ConnectorSend color: 'ffa500', message: "O Build ${BUILD_DISPLAY_NAME} <${env.BUILD_URL}> - Esta instavel ...Verifique os logs para corrigir o problema'", status: 'INSTAVEL', webhookUrl: '$WHgestao-Teams'
            }
            telegramSend("O Build ${BUILD_DISPLAY_NAME} <${env.BUILD_URL}> - Esta instavel ...Verifique os logs para corrigir o problema'")
        }
        failure {
             withCredentials([string(credentialsId: 'webhook-teams-gestao', variable: 'WHgestao-Teams')]) {
               echo ' Falhou!!! :('
               office365ConnectorSend color: 'd00000', message: "O Build ${BUILD_DISPLAY_NAME} <${env.BUILD_URL}> - Quebrou. Verifique os logs para corrigir o problema'", status: 'FALHOU', webhookUrl: '$WHgestao-Teams'
             }
             telegramSend("O Build ${BUILD_DISPLAY_NAME} <${env.BUILD_URL}> - Quebrou. Verifique os logs para corrigir o problema'")
        }
        changed {
             withCredentials([string(credentialsId: 'webhook-teams-gestao', variable: 'WHgestao-Teams')]) {
               echo 'Things were different before...'
             }
        }
    }
}