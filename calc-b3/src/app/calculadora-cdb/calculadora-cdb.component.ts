import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { CommonModule, registerLocaleData } from '@angular/common';
import localePt from '@angular/common/locales/pt';
import { LOCALE_ID } from '@angular/core';

registerLocaleData(localePt);

interface ResultadoCDB {
  ValorBruto: number;
  ValorLiquido: number;
  Erro: boolean;
  MsgErro: string | null;
}

@Component({
  selector: 'app-calculadora-cdb',
  standalone: true,
  imports: [FormsModule, CommonModule],
  providers: [
    { provide: LOCALE_ID, useValue: 'pt-BR' }
  ],
  templateUrl: './calculadora-cdb.component.html',
  styleUrls: ['./calculadora-cdb.component.css']
})
export class CalculadoraCDBComponent {
  valor: number = 0;
  prazo: number = 0;
  resultado: ResultadoCDB | null = null;

  constructor(private http: HttpClient) {}

  formatarNumero(event: any, campo: 'valor' | 'prazo', decimais: any) {
    debugger;
    const valor = parseFloat(event.target.value);
    if (!isNaN(valor)) {
      this[campo] = parseFloat(valor.toFixed(decimais));
    }
  }

  calcularCDB() {
    const dados = {
      ValorInicial: this.valor,
      Meses: this.prazo
    };

    this.http.post<ResultadoCDB>('https://localhost:44350/api/calculo/cdb/', dados)
      .subscribe({
        next: (response) => {
          if (response.Erro) {
            
            alert('Erro ao calcular CDB: ' + response.MsgErro);
          } else {
            this.resultado = response;  
          }
        },
        error: (error) => {
          
          if (error.status === 404) {
            alert('Recurso não encontrado: ' + error.error);
          } else if (error.status === 400) {
            alert('Erro ao calcular CDB: ' + error.error);
          } else {
            alert('Erro de conexão com o servidor. Tente novamente.');
          }
        }
      });
}

}
