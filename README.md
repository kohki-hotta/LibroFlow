# LibroFlow

LibroFlow は ASP.NET Core で実装されたシンプルな図書貸出管理アプリケーションです。ドメイン層を中心に、書籍・会員・貸出・予約といった基本的なモデルを備えています。

## 必要環境
- [.NET 8 SDK](https://dotnet.microsoft.com/) 以上

## 実行方法
1. リポジトリをクローンします。
2. `dotnet run --project LibroFlow/LibroFlow.csproj` を実行します。
3. ブラウザで `https://localhost:5001` (環境によりポートが異なる場合があります) にアクセスします。

## ディレクトリ構成
- **Domain**: エンティティやリポジトリインターフェースなどドメインロジックを含みます。
- **Application**: `LibraryService` を中心としたユースケースを提供します。
- **Infrastructure**: インメモリ実装のリポジトリなど、ドメインの外側の実装を置きます。
- **Controllers**: ASP.NET Core MVC/Web API のコントローラーを配置しています。

## 主要な API
- `GET /api/library/books` - 登録されている書籍一覧を取得
- `POST /api/library/loans` - 会員と書籍を指定して貸出を登録
- `POST /api/library/loans/{id}/return` - 貸出IDを指定して返却
- `GET /api/library/loans/overdue` - 期限切れとなっている貸出を取得

簡易的な実装のため、データはアプリケーション実行中のみ保持されます。実運用向けには永続化層の実装が必要です。

