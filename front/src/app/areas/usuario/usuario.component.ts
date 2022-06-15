import { Component, OnInit } from '@angular/core';
import { ApiService } from 'src/services/api.service';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-usuario',
  templateUrl: './usuario.component.html',
  styleUrls: ['./usuario.component.css']
})
export class UsuarioComponent implements OnInit {

  public nome = '';
  public idade = null;
  public cpf = null;
  public rg = '';
  public data_nasc = '';
  public endereco = '';
  public cidade = '';
  public confereCpf = null;

  public usuarios: any[] = [];

  public edita: boolean = false;

  constructor(private api: ApiService) { }

  ngOnInit() {
    this.iniciarPagina();
  }

  public iniciarPagina() {
    this.edita = false;
    this.api.get(`usuarios`).subscribe(
      (dados: any) => {
        this.usuarios = dados;
        console.table(this.usuarios);
      },
      (erro: any) => {
        alert(erro.error);
      }
    )
  }

  public editar(item: any) {
    this.edita = !this.edita;

    this.nome = item.nome;
    this.idade = item.idade;
    this.cpf = item.cpf;
    this.confereCpf = item.cpf;
    this.rg = item.rg;
    this.data_nasc = item.data_nasc;
    this.endereco = item.endereco;
    this.cidade = item.cidade;
  }

  public salvar() {
    if (this.confereCpf !== this.cpf){
      alert('Não é permitido alterar o cpf');
      return;
    }

    let item = {
      nome: this.nome,
      idade: this.idade,
      cpf: this.cpf,
      rg: this.rg,
      data_nasc: this.data_nasc,
      endereco: this.endereco,
      cidade: this.cidade
    };

    this.api.post('usuarios/Atualizar', item).subscribe(
      (dados: any) => {
        if (dados !== null || dados !== undefined) {
          alert(`Dados do usuário ${dados.nome} salvos com sucesso`);
          this.iniciarPagina();
        }
      },
      (erro: any) => {
        alert(erro.error);
      }
    )
  }

  public excluir() {
    this.api.delete('usuarios', this.cpf!).subscribe(
      (dados: any) => {
        if (dados) {
          alert('Usuário removido.');
          this.iniciarPagina();
        }
      },
      (erro: any) => {
        alert(erro.error);
      }
    )
  }

  public setCpf (item: any) {
    this.cpf = item.cpf;
    this.nome = item.nome;
  }

  public imprimir(obj: string) {
    var elemento = document.getElementById(obj);
    var html = elemento?.innerHTML;
    var printWindow = window.open(
    "",
    "",
    "left=50000,top=0,width=1000px,height=0px,toolbar=yes,location=yes,directories=yes,status=yes,menubar=yes,scrollbars=yes,resizable=yes"
    );

    var data = new Date;

    printWindow?.document.write("<html>");
    printWindow?.document.write("<head>");
    printWindow?.document.write('<style> * { font-size: 0.85rem; font-family: sans-serif; } table { border-spacing: 1em 0.2em; } thead { text-align: left; }</style>');
    printWindow?.document.write('<style>@page { size: A4; margin: 5mm 5mm 5mm 5mm; } .printCpf { white-space: nowrap; } .teste { display: none; } button { display: none; }; #linha {display:contents;}</style>');
    printWindow?.document.write("</head>");
    printWindow?.document.write("<body>");
    printWindow?.document.write("<h2>Lista de Usuários - " + data.toLocaleString() + "</h2><hr>")
    printWindow?.document.write(html ? html : '');
    printWindow?.document.write("</body>");
    printWindow?.document.write("</html>");
    printWindow?.document.close();
    printWindow?.print();
    }

}
