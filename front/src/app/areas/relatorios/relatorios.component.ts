import { Component, OnInit } from '@angular/core';
import { ApiService } from 'src/services/api.service';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-relatorios',
  templateUrl: './relatorios.component.html',
  styleUrls: ['./relatorios.component.css']
})
export class RelatoriosComponent implements OnInit {

  public faturamentoTabela: any[] = [];
  public inadimplentesTabela: any[] = [];
  public cpf = '';
  public consultaCpf = false;
  public rel = 0;
  public relFaturamento = false;
  public relInadimplentes = false;
  constructor(private api: ApiService) { }

  ngOnInit() {

  }

  public setValor(val: number = 0) {
    if(this.rel == 1){
      this.faturamento();
      this.consultaCpf = false;
    }
    else if(val == 2){
      this.inadimplentes();
    }
    else{
      this.consultaCpf = true;
      this.relFaturamento = false;
    }
  }

  public faturamento() {
    this.api.get(`Relatorios/faturamento`).subscribe(
      (dados: any) => {
        this.relFaturamento = true;
        this.relInadimplentes = false;
        this.faturamentoTabela = dados;
      },
      (erro: any) => {
        alert(erro.error);
      }
    )
  }

  public inadimplentes() {
    this.api.get(`Relatorios/inadimplentes/${this.cpf.toString()}`).subscribe(
      (dados: any) => {
        this.relFaturamento = false;
        this.relInadimplentes = true;
        this.inadimplentesTabela = dados;
        console.log(this.inadimplentesTabela);
      },
      (erro: any) => {
        alert(erro.error);
      }
    )
  }

}
