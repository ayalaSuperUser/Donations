import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { Donation } from '../models/donation';

const baseUrl = `${environment.apiUrl}/donations`;

@Injectable({
  providedIn: 'root'
})
export class DonationsService {

  constructor(private http: HttpClient) { }

  getAll() {
      return this.http.get<Donation[]>(baseUrl);
  }

  getById(id: number) {
      return this.http.get<Donation>(`${baseUrl}/${id}`);
  }

  create(params: any) {
      return this.http.post(baseUrl, params);
  }

  update(id: number, params: any) {
    console.log(id, params)
      return this.http.put(`${baseUrl}/${id}`, params);
  }

  delete(id: number) {
      return this.http.delete(`${baseUrl}/${id}`);
  }
}
