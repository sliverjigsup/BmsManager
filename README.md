# BmsManager

## BMSファイルの管理支援ツール

* 推奨環境 : SQLServer2019導入
  * SQLiteを使用したモードもあるので、SQLServer導入しなくても動きます。その場合接続文字列は無視して、exeと同階層に ```bms.db``` を作成します
  * ```appsettings.json``` の ```databaseKind``` の値を ```SQLite``` に変更してください
* 偉大なる先人様 → BeMusicSeeker ( https://tumblr.ribbit.xyz/post/129562866015/bemusicseeker-%E3%82%A2%E3%83%AB%E3%83%95%E3%82%A1%E7%89%88%E3%82%92%E5%85%AC%E9%96%8B%E3%81%97%E3%81%BE%E3%81%97%E3%81%9F )
* 現状UIは適当、かつエラーメッセージも例外の内容を表示するだけになっています。また、アプリケーションごと落ちる可能性も大いにあります
  * 一応処理中データの不整合等だけは起きないようになっているはずです
* 処理に時間がかかる場合、アプリケーションが応答しなくなる場合があります
  * 気になる部分は非同期にするようにしていますが、いろいろ漏れています
* 現在対応しているBMS拡張子はbms,bme,bml,pmsです
* 不具合、要望等はissue、または twitter ( https://twitter.com/keidrumfreak )までお願いします

## 使い方

### フォルダ管理

* フォルダパスを入力してルートフォルダを登録後、右クリックから「フォルダ読込」を選択することで、登録フォルダ以下のBMSを読み込みます
  * その際、ルートが階層構造になっていれば自動的に読み込みます
* DB登録で現在表示しているルートフォルダの状態をデータベースに記録します
  * 現在のファイルの状態を常時監視しているわけではないため、実ファイルの状態と食い違う場合があります
* 自動リネームを実行すると現在表示中の全てのフォルダをフォルダ内のBMSのTITLE,ARTISTから自動的にリネームします (```[ARTIST] TITLE```となります)
  * BMSファイルの内容によってはTITLE,ARTISTが空になる場合があります
* テキストボックスに名称を入力して手動リネームを実行できます
  * BMSファイルを選択すると該当BMSファイルからTITLE,ARTISTを生成してテキストボックスに表示します
* フォルダの右クリックメニューから対象フォルダをエクスプローラで開けます

![image](https://user-images.githubusercontent.com/7110616/129185905-47e2304c-bc35-47f5-9cb8-054916f7e97c.png)

### 難易度表管理

* URLを入力して新規読み込みを実行することで難易度表を読み込みます
  * GLAssist対応のフォーマットのものが読み込めます
  * 画面表示時はDBの内容を読み込むため、更新したい場合は難易度表を右クリックして更新を実行してください
* 差分一括DLで現在表示中の全て差分を可能な限りDLします
  * URLの形式によってはDLできない、または変なファイルがDLされる可能性があります
* 差分を右クリックすることで本体URL,差分URL,パッケージURL,LRIRをブラウザで開くことができます

![image](https://user-images.githubusercontent.com/7110616/129187837-b593b3f2-d00f-46fe-98ac-e143ee949b3b.png)

### 重複ファイルチェック

* MD5、またはタイトルとアーティストの組み合わせで重複BMSのチェックができます
* フォルダの右クリックから対象フォルダへの統合を行うことができます
  * 対応しているBMSファイルはMD5をチェックし、同一でなければリネームして統合します
  * それ以外のファイルは統合先を正として、重複しているものを削除します
* ファイルを右クリックでbmsファイル単体の削除を行えます
  * ファイルの削除自体はフォルダ管理画面からも実行できます

![image](https://user-images.githubusercontent.com/7110616/129188946-3a85c419-03fd-4f4f-9ea8-79f9aa21e823.png)

### 差分登録

* 現状BMSファイル単体の差分にのみ対応しています
  * 現状追加音源などがある差分の場合はフォルダ管理から対象フォルダを開いて導入、リロード後にDB登録してください
  * インストール先推定不能の場合も同様の手順で導入になります
* フォルダ読み込みで指定したフォルダ以下にある対応BMSファイルを読み込みます
* 右クリックでインストール先を推定、または「全部推定」ボタンを押下することでTITLE,ARTISTからインストール先の推定を行います
* 難易度表からインストールを実行することで表示中のBMSファイルが読込済の難易度表にあり、かつOrgMD5が設定されていれば、対象のフォルダにBMSファイルをコピーします
* インストール先推定済の場合差分をクリックすることで推定先のフォルダの一覧が表示されます
* フォルダを右クリック後、「このフォルダにインストール」をクリックすることで対象のフォルダにBMSファイルを移動、DBの更新を行います
* 「全部インストール」を実行することで、推定先が1つしか無いファイルを全て対象フォルダに導入します
  * 別曲でも推定先として一致してしまう場合があるため、実施前に一度ファイル毎に推定先の確認だけ行っておくことを推奨します

![image](https://user-images.githubusercontent.com/7110616/129190432-22b2c1e9-ae45-4aa0-a0fd-af5c7adb6ee5.png)


