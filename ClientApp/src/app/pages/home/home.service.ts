import { Injectable } from '@angular/core';
import { Sorting } from 'devextreme/ui/data_grid';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';
import { map } from 'rxjs/operators';
import { environment } from "../../../environments/environment"


export class ViewMeasuring {
    id!: number;
    parameter_id!: number;
    meter_id!: number;
    value!: string;
    value_dt!: string;
}

export class Parameters {
    id!: number;
    caption!: string;
    measure_units!: string;
}

export class Meters {
    constructor(public id: number, public caption: string) {
    }
}

export class Measuring {
    constructor(public meterId: number, public value_dt: string,
        public actR: number, public actO: number, public reactR: number, public reactO: number) {
    }
}


@Injectable()
export class HttpService {

    constructor(private http: HttpClient) { }

    getMeasuring(meterId: number, value_dt:string): Observable<Measuring[]> {
        return this.http.get(environment.apiUrl + meterId + '/' + value_dt).pipe(map((data: any) => {
            let measuring = data;
            return measuring.map(function (measuring: any): Measuring {
                return new Measuring(measuring.meterId, measuring.value_dt, measuring.actR, measuring.actO, measuring.reactR, measuring.reactO);
            });
        }));
    }

    getMeters(): Observable<Meters[]> {
        return this.http.get(environment.apiUrl).pipe(map((data: any) => {
            let meters = data;
            return meters.map(function (meters: any): Meters {
                return new Meters(meters.id, meters.caption);
            });
        }));
    }
}


