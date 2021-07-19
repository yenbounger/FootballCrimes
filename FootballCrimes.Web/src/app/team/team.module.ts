import { NgModule } from '@angular/core';
import { CommonModule, DatePipe } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { TeamSummaryComponent } from './team-summary/team-summary.component';
import { SharedModule } from '../shared/shared.module';
import { TeamsComponent } from './teams/teams.component';
import { TeamCardComponent } from './teams/team-card/team-card.component';
import { FlexLayoutModule } from '@angular/flex-layout';
import { MatCardModule } from '@angular/material/card';
import { CrimeCountByMonth } from './team-summary/total-crimes-by-year/crime-count-by-month.component';
import { NgxChartsModule } from '@swimlane/ngx-charts';
import { CrimesByTypeComponent } from './team-summary/crimes-by-type/crimes-by-type.component';
import { CrimeTypePipe } from '../shared/crime-type.pipe';
import {MatTabsModule} from '@angular/material/tabs';
import { GraphCardComponent } from './team-summary/graph-card/graph-card.component';

const routes: Routes = [
  {
    path: '',
    component: TeamsComponent
  },
  {
    path: ':id',
    component: TeamSummaryComponent
  }];
@NgModule({
  declarations: [
    TeamSummaryComponent,
    TeamsComponent,
    TeamCardComponent,
    CrimeCountByMonth,
    CrimesByTypeComponent,
    GraphCardComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    RouterModule.forChild(routes),
    FlexLayoutModule,
    MatCardModule,
    NgxChartsModule,
    MatTabsModule
  ],
  providers: [CrimeTypePipe]
})
export class TeamModule { }
