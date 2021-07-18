export interface TableData {
  count: number;
  crimeData: CrimeData[];
}

export interface CrimeData {
  teamId: string;
  teamCrestUrl: string;
  teamName: string;
  stadiumName: string;
  crimeType: number;
  dateCommited: Date;
}
