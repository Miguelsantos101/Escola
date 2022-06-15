import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { GuardGuard } from 'src/services/guard.guard';
import { CadastroComponent } from './areas/cadastro/cadastro.component';
import { ContratacaoComponent } from './areas/contratacao/contratacao.component';
import { LoginComponent } from './areas/login/login.component';
import { PrincipalComponent } from './areas/principal/principal.component';
import { RelatoriosComponent } from './areas/relatorios/relatorios.component';
import { ServicosComponent } from './areas/servicos/servicos.component';
import { UsuarioComponent } from './areas/usuario/usuario.component';

const routes: Routes = [
  {
    path: 'login',
    component: LoginComponent,
  },
  {
    path: 'principal',
    component: PrincipalComponent, canActivate: [GuardGuard],
    children: [
      { path: 'usuarios', component: UsuarioComponent },
      { path: 'cadastro', component: CadastroComponent },
      { path: 'servicos', component: ServicosComponent },
      { path: 'contratacao', component: ContratacaoComponent },
      { path: 'relatorios', component: RelatoriosComponent},
    ],
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
