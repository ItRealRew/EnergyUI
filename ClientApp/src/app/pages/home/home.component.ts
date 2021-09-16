import { Component, OnInit } from '@angular/core';
import DataSource from 'devextreme/data/data_source';
import { Measuring, HttpService, Meters } from './home.service';



@Component({
  templateUrl: 'home.component.html',
  styleUrls: ['./home.component.css'],
  providers: [HttpService]
})

export class HomeComponent implements OnInit {

  meters: Meters[] = [];
  measuring: Measuring[] = [];
  value_dt: string = "2021-08-01T01:00:00";

  constructor(private httpService: HttpService) {
    this.httpService.getMeters().subscribe((data: Meters[]) => this.meters = data);
  }

  changeMeters(meterId:number) {
    this.httpService.getMeasuring(meterId,this.measuring[0].value_dt).subscribe((data: Measuring[]) => this.measuring = data);
  }

  changeDate(e: { value: any; })
  {
    this.httpService.getMeasuring(1,e.value).subscribe((data: Measuring[]) => this.measuring = data);
  }

  ngOnInit() {
    this.httpService.getMeasuring(1,this.value_dt).subscribe((data: Measuring[]) => this.measuring = data);
  }
}
