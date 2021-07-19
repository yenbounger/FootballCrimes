import { CrimeType } from "src/app/shared/crime-type.enum";
import { TeamCard } from "../teams/team-card/team-card.model";

export interface Team extends TeamCard {
  stadiumAddress: string;
  stadiumLat: string;
  stadiumLng: string;
  teamCrimes: TeamCrime[];
}

export interface TeamCrime {
  crimeType: CrimeType;
  dateCommited: Date
}
