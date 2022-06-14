import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ApiService } from 'src/services/api.service';

@Component({
  selector: 'app-contratacao',
  templateUrl: './contratacao.component.html',
  styleUrls: ['./contratacao.component.css']
})
export class ContratacaoComponent implements OnInit {

  public cpf = '';

  public retorno: any = [];
  public servicos: any = [];
  public envio: any = [];
  public id_servicos_contratados: number = 0;

  public verifica: boolean = false;

  constructor(
    private api: ApiService
  ) { }

  ngOnInit() {
    this.carregaServicos()
  }

  public carregaServicos() {
    this.api.get('contratacao/servicos').subscribe({
      next: dados => {
        this.servicos = dados;
      },
      error: erro => alert(erro.error)
    })
  }

  public buscaCpf() {
    this.api.get(`contratacao/${this.cpf}`).subscribe({
      next: dados => {
        this.retorno = dados;
        const v = this.retorno.find((e: any) => e.descricao == 'VAZIO');
        this.verifica = (v?.descricao == 'VAZIO') ? true : false;
        console.table(this.retorno);
        console.log(this.verifica);
      },
      error: erro => alert(erro.error)
    })
  }

  public insereServico(id: number){
    this.envio.push({
      id_servico: id,
      cpf_usuario: this.cpf
    });
  }

  public contrataServico() {
    if (this.envio.length == 0){
      alert('Selecione ao menos um serviço');
      return;
    }
    this.api.post('contratacao', this.envio).subscribe(
      () => {
        alert('Serviços contratados')
        this.carregaServicos()
      },
      (erro: any) => {
        alert(erro.error);
      },
      () => {
        this.buscaCpf();
        this.envio = [];
      }
    )
  }

  public removeServico(id_servicos_contratados: number) {
    this.api.deleteId(`contratacao`, id_servicos_contratados).subscribe(
      (dados: any) => {
        if (dados) {
          alert('Serviço removido.');
          this.carregaServicos();
          this.buscaCpf();
        }
      },
      (erro: any) => {
        alert(erro.error);
      }
    )
  }

}
