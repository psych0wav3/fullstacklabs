export interface NewBalancePayload{
  Value: number,
	Currency: Currency;
}

export enum Currency{
  BRL,
  USD,
  EUR
}

export interface Balance{
  value: number;
  currency: Currency;
}

export enum Type{
  Conversão,
  Adição
}

export interface Moviments{
  value: number,
  type: any,
  oldCurrency: any,
  newCurrency: any,
  id: string;
}
