import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ApiService } from 'src/services/api.service';
import { LoginService } from 'src/services/login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  form!: FormGroup
  visivel: boolean = true;

  constructor(
    private api: ApiService,
    private fb: FormBuilder,
    private router: Router,
    private login: LoginService) { }

  ngOnInit() {
    this.validaForm();
    this.visivel = !this.login.autenticado();
  }

  public validaForm() {
    this.form = this.fb.group({
      cpf: ['', Validators.required],
      hash_senha: ['', Validators.required]})
  }

  public logar() {
    this.api.post(`Login/logar`, this.form.value).subscribe({
      next: dados => {
        if(dados){
          this.router.navigate(['/principal']);
          this.visivel = false;
          this.login.salvaUsuarioLogado(this.form.value);
        }
      }
    })

  }

  public deslogar() {

  }
}
