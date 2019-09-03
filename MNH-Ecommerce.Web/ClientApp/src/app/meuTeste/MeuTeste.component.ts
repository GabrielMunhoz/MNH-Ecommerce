import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'MeuTeste',
  templateUrl: './MeuTeste.component.html'
})
export class MeuTesteComponente {
  public forecasts: WeatherForecast[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<WeatherForecast[]>(baseUrl + 'api/SampleData/WeatherForecasts').subscribe(result => {
      this.forecasts = result;
    }, error => console.error(error));
  }
}

interface User {
  Nome: string;
  Idade: number;
  Apelido: string;
  Sexo: string;
}
