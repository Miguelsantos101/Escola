import { Component, OnInit } from '@angular/core';
import { ApiService } from 'src/services/api.service';

@Component({
  selector: 'app-servicos',
  templateUrl: './servicos.component.html',
  styleUrls: ['./servicos.component.css']
})
export class ServicosComponent implements OnInit {

  public servicos: any[] = [];

  constructor(private api: ApiService) { }

  ngOnInit() {
    this.iniciarPagina();
  }

  public iniciarPagina() {
    this.api.get(`servicos`).subscribe(
      (dados: any) => {
        this.servicos = dados;
        console.table(this.servicos);
      },
      (erro: any) => {
        alert(erro.error);
      }
    )
  }
}
