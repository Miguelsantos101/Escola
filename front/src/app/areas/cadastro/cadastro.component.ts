import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, FormsModule, Validators } from '@angular/forms';
import { ApiService } from 'src/services/api.service';

@Component({
  selector: 'app-cadastro',
  templateUrl: './cadastro.component.html',
  styleUrls: ['./cadastro.component.css']
})
export class CadastroComponent implements OnInit {

  public form!: FormGroup;

  // public nome: string = '';
  // public idade: number = 0;
  // public cpf: string = '';
  // public rg: string = '';
  // public data_nasc: string = '';
  // public endereco: string = '';
  // public cidade: string = '';


  constructor(
    private api: ApiService,
    private fb: FormBuilder
    ) { }

  get f(): any {
    return this.form.controls;
  }

  ngOnInit() {
    this.validaForm();
  }

  public validaForm() {
    this.form = this.fb.group({
      nome: ['', Validators.required],
      idade: ['',
        [Validators.required,
        Validators.pattern('[0-9]*')]],
      cpf: ['',
        [Validators.required,
        Validators.minLength(11),
        Validators.maxLength(11)]],
      rg: ['',
        [Validators.required,
        Validators.minLength(9),
        Validators.maxLength(9)]],
      data_nasc: ['', Validators.required],
      endereco: ['', Validators.required],
      cidade: ['', Validators.required]
    });
  }

  public incluir(){
    this.api.post('usuarios/Inserir', this.form.value).subscribe(
      (dados: any) => {
        if (dados !== null || dados !== undefined) {
          alert(`Usuário ${dados.nome} salvo com sucesso`);
        }
      },
      (erro: any) => {
        alert(erro.error);
      }
    )
  }
}
