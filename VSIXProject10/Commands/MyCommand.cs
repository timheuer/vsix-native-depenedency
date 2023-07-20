namespace VSIXProject10;

[Command(PackageIds.MyCommand)]
internal sealed class MyCommand : BaseCommand<MyCommand>
{
    protected override async Task ExecuteAsync(OleMenuCmdEventArgs e)
    {
        var secretValue = System.Text.Encoding.UTF8.GetBytes("mySecret");
        var publicKey = Convert.FromBase64String("2Sg8iYjAxxmI2LvUXpJjkYrMxURPc8r+dB7TJyvvcCU=");

        var sealedPublicKeyBox = Sodium.SealedPublicKeyBox.Create(secretValue, publicKey);

        Console.WriteLine(Convert.ToBase64String(sealedPublicKeyBox));

        await VS.MessageBox.ShowWarningAsync("VSIXProject10", "Button clicked");
    }
}
