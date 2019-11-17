import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-value',
  templateUrl: './value.component.html',
  styleUrls: ['./value.component.css']
})
export class ValueComponent implements OnInit {

  // declare property called values
  // allow us with what contains inside, like var command in c#
  values: any;

  // injecting Http Client
  // http is the name of variable
  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getValues();
  }

  // returns observable
  // observable - stream of data let's coming back from server
  // subscribe - first parameter takes callback, second paramter event of an error, third received data
  getValues() {
    this.http.get('http://localhost:5000/WeatherForcast').subscribe(response => {
      this.values = response;
    }, error => {
      console.log(error);
    });
  }

}
