import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';

import {Mesuring} from './measuring';

@Injectable()
export class ApiService {

  constructor(private http: HttpClient) { }

  getMeasuring(): Observable<Mesuring[]> {
    return this.http.get<Mesuring[]>('https://localhost:5001/energy/api/1/2021-08-01T01:00:00');
  }

}