import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { RouterModule } from '@angular/router';
import { TableComponent } from './table/table.component';
import { MatTableModule } from '@angular/material/table';
import { MatToolbarModule } from '@angular/material/toolbar';
import { HttpClientModule } from '@angular/common/http';
import { SharedModule } from './shared/shared.module';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSortModule } from '@angular/material/sort';
import { MatCardModule } from '@angular/material/card';
const routes = [{
  path: 'table',
  component: TableComponent
},
{
  path: 'team',
  loadChildren: () => import('./team/team.module').then(m => m.TeamModule)
},
{
  path: '**',
  component: TableComponent
}]
@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    TableComponent,
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    RouterModule.forRoot(routes),
    MatToolbarModule,
    MatTableModule,
    HttpClientModule,
    MatPaginatorModule,
    SharedModule,
    MatSortModule,
    MatCardModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
