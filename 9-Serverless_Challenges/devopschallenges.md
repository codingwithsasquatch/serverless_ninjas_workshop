# サーバーレス DevOps チャレンジ

このチャレンジではサーバーレス開発環境に DevOps を導入してもらいます。 


## チャレンジ 1. ローカル環境の構築

開発中のソリューションが成功し、人気が出てきたため、新しいメンバーがチームに参画してきます。
各メンバー用に並行して開発できる環境を用意する必要があります。

### 要件

ローカル開発環境を構築します。C# または Javascript のどちらを利用しても構いません。

### 成功要件

* ストレージエミュレータを使って、ローカルで Functions が実行できる
* ローカルでブレークポイントを使ったライブデバッグが実行できる
* Functions を Azure に展開できる

### 参照

* [Create your first function using Visual Studio](https://docs.microsoft.com/en-us/azure/azure-functions/functions-create-your-first-function-visual-studio)
* [Create your first function using Visual Studio Code](https://docs.microsoft.com/en-us/azure/azure-functions/functions-create-first-function-vs-code)



## チャレンジ 2. CI/CD パイプライン

チームでプライベートレポジトリを使ったコードの共有が必要です。Azure DevOps を使って CI/CD パイプラインを構築します。

## 要件

コードと簡単なユニットテストを Azure DevOps に上げます。プルリクエストを登録したタイミングで、ビルドとテストが実行さる事とマージされた場合はビルド、テスト、および Azure への展開が出来る事が要件です。

## 成功条件
     
* プライベートレポジトリでコードの共有ができる
* プルリクエストの作成をトリガーに CI パイプラインが実行され、最低 1 つのユニットテストが実行される
* master ブランチへの変更を自動で検知し、ビルド、テスト、展開が行われる。

### 参照

* [Azure Repos Git Tutorial](https://docs.microsoft.com/en-us/azure/devops/repos/git/gitworkflow?view=vsts)
* [Serverless, DevOps, and CI/CD: Part 2](https://medium.com/microsoftazure/serverless-devops-and-ci-cd-part-2-b6e0a6d05530)
* [Azure Functions CI/CD pipeline for Node.js using VSTS](https://blogs.technet.microsoft.com/livedevopsinjapan/2017/12/13/azure-functions-cicd-pipeline-for-node-js-using-vsts/)

## チャレンジ 3. コンテナへのデプロイ

開発したファンクションを他の部署でも利用したいという要望がありますが、他の部署は Azure 環境へのアクセス権がなく、設置型環境で実行したいと言われています。このチャレンジではファンクションをコンテナ化します。

## 要件

ファンクションを Docker コンテナ化し、ローカル環境で実行できるようにします。またコンテナは Docker Hub か Azure コンテナレジストリーで共有し、Azure 上でも実行できるようにします。

## 成功条件

* Docker コンテナ化したファンクションがローカル環境で実行できる
* コンテナイメージが DockerHub または Azure コンテナレジストリーにアップロードされる
* Azure 上の Docker 環境で実行できる

Azure で Docker を実行する方法は以下の方法から選択してください。

1. Azure Functions
2. Azure Container Instances
3. Azure Kubernetes Service.
4. Azure Web Apps

### 参照 

* [Create a function on Linux using a custom image (preview)](https://docs.microsoft.com/en-au/azure/azure-functions/functions-create-function-linux-custom-image)
* [Quickstart: Create your first container in Azure Container Instances](https://docs.microsoft.com/en-us/azure/container-instances/container-instances-quickstart-portal) 
* [Deploy a function to Kubernetes](https://github.com/Azure/azure-functions-core-tools#deploy-a-function-to-kubernetes)

