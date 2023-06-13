# Projeto desafio para logar utilizando Azure AD B2C
O projeto consiste em nas seguintes atividades:
1. Criar uma API básica utilizando o template do próprio Visual Studio que cria um retorno de privões metereológicas geradas em memória. No projeto esta API tem o nome de **SecureWebApiSample**
2. Publicar API criando no Azure um recurso do tipo App Service:
![image](https://github.com/breula/AvanadeMauiMsalAuth/assets/17342213/a1d25efa-cd47-4c2c-9f71-a40c9650f5bb)<br>
De dentro do Visual Studio você tem as opções de criar automaticamente essa API direto no Azure no momento em que for publicá-la "Publish" bastando informar os dados de sua subscription.
3. Criar uma aplicação dentro da mesma solution para o app MAUI e implementar o que for necessário e as alterações que julgar interessantes.
4. De volta ao Azure é necessário criar um "***B2C Tenants***" 
se desejar que seu aplicativo seja configurado em um diretório diferente do principal, tipo "isolar" sua aplicação para no caso de exisitr mais de uma. Depois é necessário criar e configurar o AD clicando em
"***Azure AD B2C***" Se não deseja isolar já pode ir direto neste sem criar o tenant e assim o aplicativo a ser registrado ficará no diretório defalt da sua Azure Subscription. 

# O que será necessário saber ou irá aprender utilizando este repositório?
1. Converters
2. Utilizar o MVVM **[ObservableProperty]** do Community Toolkit para tornar propriedades observáveis de maneira mais fácil, vulgo "mão na roda".
3. Procure saber a diferença entre injeções "AddSingleton" e "AddTransient" aconselho assistir a este vídeo: https://www.youtube.com/watch?v=oC5zpEbwViE&t=166s
4. Criar e injetar seu próprio controle de Alert Messagens e Diálogos.
5. Binding utilizando ViewModel.
6. Utilizar o novo **[RelayCommand]** trazido pelo MAUI que substitui de forma grandiosa a trabalheira de implementar na mão os Commands que são utilizados na camada de apresentação.

# ATENÇÃO PARA
É importante notar que os dados mais importantes estão nos arquivos "appsettings.json" na api e no arquivo "PCAWrapper" do projeto no app MAUI. Nestes arquivos estão os dados que devem ser informados de acordo com os cadastros efetuados em sua conta Azure no momento da criação de API, registro de aplicação, criação de Tenants e configuração do Azure Ad B2C.
Estes dados aqui neste projeto foram retirados por segurança. Então se apenas clonar o projeto e executar o app não irá funcionar de maneira correta, não vai logar e por consequência não vai consumir API, etc.. etc..
***Para funcionar com tigo é necessário criar o seu lado no Azure e informar os seus dados, ok?***
Seguir o tuturial do vídeo abaixo pode te ajudar na configuração do Azure.<br>
https://www.youtube.com/watch?v=p8NRvakFW2M&t=1284s


Tela home.<br>
![Screenshot_1686602292](https://github.com/breula/AvanadeMauiMsalAuth/assets/17342213/9dc8100b-00d5-4bef-a9cb-6c614f8e947e)

Chamada do já conhecido login Microsoft. à partir daqui a Microsoft comanda e para logar é necessário seguir o fluxo.<br>
![Screenshot_1686602308](https://github.com/breula/AvanadeMauiMsalAuth/assets/17342213/2bfa5d6a-d8c7-466b-a18d-d10b7f91ecc9)

Depois de autenticado pelo AD do Azure.<br>
![Screenshot_1686602316](https://github.com/breula/AvanadeMauiMsalAuth/assets/17342213/c1a7c2a7-546d-4fd1-9377-bdc1a7cb05cc)

Mostrando previsão do tempo rertonada pelo nossa API.<br>
![Screenshot_1686602323](https://github.com/breula/AvanadeMauiMsalAuth/assets/17342213/c196df5e-d359-4e6e-9519-da285776732a)

Log off da conta.<br>
![Screenshot_1686602329](https://github.com/breula/AvanadeMauiMsalAuth/assets/17342213/7b73a954-c6d5-463d-be04-f3f8edeedcec)
