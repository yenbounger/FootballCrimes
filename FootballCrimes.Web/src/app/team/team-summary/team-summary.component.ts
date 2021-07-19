import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { TeamsService } from '../teams/teams.service';
import { Team } from './team.model';

@Component({
  selector: 'app-team-summary',
  templateUrl: './team-summary.component.html',
  styleUrls: ['./team-summary.component.scss']
})
export class TeamSummaryComponent implements OnInit {
  teamId!: string;
  team$!: Observable<Team>;
  constructor(private route: ActivatedRoute, private teamsService: TeamsService) {
    this.route.params.subscribe(params => {
      this.teamId = params.id;
    });
  }

  ngOnInit(): void {
    this.team$ = this.teamsService.getTeamById(this.teamId);
  }

}
