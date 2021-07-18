import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { TeamCard } from './team-card/team-card.model';

@Injectable({
  providedIn: 'root'
})
export class TeamsService {

  constructor(private http: HttpClient) { }

  getTeamsData() {
    return this.http.get<TeamCard[]>(`${environment.apiUrl}/teams`)
  }
}
