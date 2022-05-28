using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;

namespace ManagePost;

public partial class MainPage : ContentPage
{
	int count = 0;

    public async void MisskeyPost(string postText)
    {
        var param = new Dictionary<string, object>()
        {
            ["i"] = "",
            ["text"] = postText,
        };
        var jsonString = System.Text.Json.JsonSerializer.Serialize(param);
        var content = new StringContent(jsonString, Encoding.UTF8, @"application/json");
        var client = new HttpClient();
        var result = await client.PostAsync(@"https://misskey.io/api/notes/create", content);
    }


    public MainPage()
	{
		InitializeComponent();
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times";

		SemanticScreenReader.Announce(CounterBtn.Text);
	}

    private void editorCompleted(object sender, EventArgs e)
    {
        InputSet.Text = editor.Text;
        editor.Text = "";

    }

}

