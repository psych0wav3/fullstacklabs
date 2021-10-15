import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import {NgbModal, ModalDismissReasons} from '@ng-bootstrap/ng-bootstrap';
import { Currency, Type, NewBalancePayload } from './types';

interface Endpoints {
  balance: string;
  moviments: string;
  convert: string;
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  title = 'Monetize';
  brl = 100;
  usd =  100;
  eur = 100;

  newBalance: string = '';
  convertBalance: string = '';
  convertCoin: any;

  moviments: any;

  private readonly baseURL: string = 'https://localhost:5001';
  private readonly endpoints: Endpoints = {
    balance: '/balance',
    moviments: '/moviments',
    convert: '/convert',
  }


  closeResult: string = '';
  constructor(
    private modalService: NgbModal,
    private http : HttpClient
  ) {}
  ngOnInit(): void {
    this.getBalance();
    this.getMoviments()
  }

  getBalance() {
    this.http.get(`${this.baseURL}${this.endpoints.balance}`)
    .subscribe( response => {

      let data = [];

      for (const [,item] of Object.entries(response)){
        data.push(item)
      }

      this.brl = data[0].value;
      this.usd = data[1].value;
      this.eur = data[2].value;
    },
    error => {
      alert('Algo deu errado!')
    }
    );
  }

  getMoviments(){
    this.http.get(`${this.baseURL}${this.endpoints.moviments}`)
    .subscribe(response => {
      let data = [];

      for(const [, item] of Object.entries(response)){
        data.push(item)
      }

      this.moviments = data.map((item) => {
        return {
          id: item.id,
          value: item.value,
          type: Type[item.type],
          oldCurrency: Currency[item.oldCurrency],
          newCurrency: Currency[item.newCurrency],
        }
      })

    }, error => alert('Algo deu errado!'))
  }

  setNewBalance(){
    const payload: NewBalancePayload = {
      Value: parseFloat(this.newBalance),
      Currency: Currency.BRL
    }
    this.http.put(`${this.baseURL}${this.endpoints.balance}`, payload)
    .subscribe(response => {
      alert("deposito realizado com sucesso!");
      this.modalService.dismissAll();
    }, error => {
      alert("Algo deu errado1");
      this.modalService.dismissAll();
    })
  }

  onSelectCoin(){
    this.convertCoin = +this.convertCoin;
  }

  setCoinConvertion(){
    const payload = {
      Value: parseFloat(this.convertBalance),
      Currency: this.convertCoin,
    }

    this.http.post(`${this.baseURL}${this.endpoints.convert}`, payload)
    .subscribe(response => {
      alert("conversão realizada com sucesso");
      this.modalService.dismissAll();
    }, error => {
      alert("algo deu errado");
      this.modalService.dismissAll();
    })
    console.log(payload)
  }

  open(content:any) {

    this.modalService.open(content, {ariaLabelledBy: 'modal-basic-title'}).result.then((result) => {

      this.closeResult = `Closed with: ${result}`;

    }, (reason) => {

      this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;

    });

  }

  private getDismissReason(reason: any): string {

    if (reason === ModalDismissReasons.ESC) {

      return 'by pressing ESC';

    } else if (reason === ModalDismissReasons.BACKDROP_CLICK) {

      return 'by clicking on a backdrop';

    } else {

      return  `with: ${reason}`;

    }

  }

}
