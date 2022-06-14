import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CadastroComponent } from './areas/cadastro/cadastro.component';
import { ContratacaoComponent } from './areas/contratacao/contratacao.component';
import { ServicosComponent } from './areas/servicos/servicos.component';
import { UsuarioComponent } from './areas/usuario/usuario.component';

const routes: Routes = [
 {path: 'usuarios', component: UsuarioComponent},
 {path: 'cadastro', component: CadastroComponent},
 {path: 'servicos', component: ServicosComponent},
 {path: 'contratacao', component: ContratacaoComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
