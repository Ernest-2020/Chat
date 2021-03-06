using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private Button buttonStartServer;
    [SerializeField]
    private Button buttonShutDownServer;
    [SerializeField]
    private Button buttonConnectClient;
    [SerializeField]
    private Button buttonDisconnectClient;
    [SerializeField]
    private Button buttonSendMessage;


    [SerializeField]
    private TMP_InputField inputField;
    [SerializeField]
    private TMP_InputField inputFieldName;


    [SerializeField]
    private TextField textField;

    [SerializeField]
    private Server server;
    [SerializeField]
    private Client client;

    private void Start()
    {
        buttonStartServer.onClick.AddListener(() => StartServer());
        buttonShutDownServer.onClick.AddListener(() => ShutDownServer());
        buttonConnectClient.onClick.AddListener(() => Connect());
        buttonDisconnectClient.onClick.AddListener(() => Disconnect());
        buttonSendMessage.onClick.AddListener(() => SendMessage());
        inputField.onEndEdit.AddListener((text) => SendMessage());
        client.onMessageReceive += ReceiveMessage;
    }

    private void StartServer() =>
        server.StartServer();

    private void ShutDownServer() =>
        server.ShutDownServer();

    private async void Connect()
    {
        client.Connect();
        await Task.Delay(1000);
        SendName();
    }

    private void Disconnect() =>
        client.Disconnect();

    private void SendMessage()
    {
        client.SendMessage(inputField.text);
        inputField.text = "";
    }
    private void SendName()
    {
        client.SendMessage(inputFieldName.text);
        inputField.text = "";
    }
    public void ReceiveMessage(object message) =>
        textField.ReceiveMessage(message);

}
