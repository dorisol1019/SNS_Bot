using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mastonet;

namespace MastodonAccessTokenGetter
{
    class Program
    {
        static void Main(string[] args)
        {
            MainProgram().Wait();
        }

        static public async Task MainProgram()
        {
            Scope scope = Scope.Read | Scope.Write | Scope.Follow;

            Console.WriteLine("インスタンス名を入力してください");
            string instance = Console.ReadLine();


            Console.WriteLine("アプリケーション名を入力してください");
            string appName = Console.ReadLine();


            var app = await MastodonClient.CreateApp(instance, appName, scope);

            Console.WriteLine("あなたのアプリの設定はこちらになります");
            Console.WriteLine($"Id  = {app.Id}");
            Console.WriteLine($"ClientId = {app.ClientId}");
            Console.WriteLine($"ClientSecret = {app.ClientSecret}");
            Console.WriteLine($"Instance = {app.Instance}");

            var client = new Mastonet.MastodonClient(app);

            Console.WriteLine("認証してコードをゲットしてください");

            var url = client.OAuthUrl();

            System.Diagnostics.Process.Start(url);

            Console.WriteLine("アクセストークンを取得するためのコードを入力してください");
            string code = Console.ReadLine();

            var auth=await client.Connect(code);

            Console.WriteLine("アクセストークンはこちらになります");
            Console.WriteLine(auth.AccessToken);


        }
    }
}
