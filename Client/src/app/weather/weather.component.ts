import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-weather',
  templateUrl: './weather.component.html',
  styleUrls: ['./weather.component.scss']
})
export class WeatherComponent implements OnInit {
  weatherData: any;

  constructor(private http: HttpClient){
    this.http.get('/api/weather').subscribe(data => this.weatherData = data);
  }
  ngOnInit(): void {
  }

}
