using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Firebase;
using Firebase.Unity.Editor;
using Firebase.Auth;

public class Register : MonoBehaviour
{
    // Start is called before the first frame update
    
    public InputField InputName;
    public InputField InputEmail;
    public InputField InputPassword;
    public InputField InputConfirmPassword;

    public Button[] buttons;
    public InputField[] inputFields;

    public Text idLogado, nickLogado, emailLogado;

    private FirebaseAuth auth;
    private FirebaseUser user;

    public void TelaRegister()
    {
        SceneManager.LoadScene("Register");
    }
    public void ButtonVoltar()
    {
        SceneManager.LoadScene("Login");
    }

    void Start()
    {
        IniciarFirebase();    
    }

    public void IniciarFirebase()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => {

            var dependencyStatus = task.Result;

            if (dependencyStatus == DependencyStatus.Available)
            {
                Debug.Log("Verificação concluída, Firebase ativado");
                Debug.Log("Teste");
            
                auth = FirebaseAuth.DefaultInstance;

              

                auth.StateChanged += AuthStateChanged;
                AuthStateChanged(this, null);
                Debug.Log("Teste2");
            }

            else
            {
                Debug.LogError(System.String.Format("Não foi possível resolver todas as dependências do Firebase: {0}", dependencyStatus));
            }

        });
    }

    void AuthStateChanged(object sender, System.EventArgs eventArgs)
    {
        Debug.Log("Usuário");
        
        if (auth.CurrentUser != user)
        {
            bool signedIn = user != auth.CurrentUser && auth.CurrentUser != null;

            if (!signedIn && user != null)
            {
                Debug.Log("Usuário foi Desconectado");
            }

            user = auth.CurrentUser;

            if (signedIn)
            {
                Debug.Log("Usuario Conectado");
            }
        }
    }

    void OnDestroy()
    {
        auth.StateChanged -= AuthStateChanged;
         auth = null;
    }
    public async void ButtonRegister()
    {
        string name = this.InputName.text;
        string login = this.InputEmail.text;
        string passoword = this.InputPassword.text;
        string confirm = this.InputConfirmPassword.text;
        Debug.Log("Teste");
        if (InputPassword.text == InputConfirmPassword.text)
        {
            await auth.CreateUserWithEmailAndPasswordAsync(InputEmail.text, InputPassword.text).ContinueWith(task =>
            {
                
                if (task.Result == null)
                {
                    Debug.Log("Ocorreu um erro no cadastro");
                }
                else
                {
                    Debug.Log("Cadastro efetuado com sucesso");
                    EnviarEmailVerificacao();
                    SceneManager.LoadScene("Login");
                    Logout();
                }
            });
            
        }
        else
        {
            Debug.Log("Confirmação de senha inválida");
        }
    }
    public async void EnviarEmailVerificacao()
    {
        if (auth.CurrentUser != null)
        {
            await auth.CurrentUser.SendEmailVerificationAsync().ContinueWith(task => {
                Debug.Log(task.Status);
            });
            Debug.Log("Email enviado com sucesso");
        }
    }

    public void Perfil()
    {
        if (auth.CurrentUser != null)
        {
            Debug.Log(auth.CurrentUser.UserId);
        }
    }
    public void Logout()
    {
        auth.SignOut();
    }

    public async void Login()
    {
        await auth.SignInWithEmailAndPasswordAsync(InputEmail.text, InputPassword.text).ContinueWith(task =>
        {
           
        });
        if (auth.CurrentUser != null)
        {

            if (auth.CurrentUser.IsEmailVerified == false)
            {
                Logout();

                Debug.Log("Você ainda não verificou o link que foi enviado no e-mail");
            }
            else
            {
                SceneManager.LoadScene("Menu");
            }
        }
        else
        {
            Debug.Log("Login ou estão errados");
        }


    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
