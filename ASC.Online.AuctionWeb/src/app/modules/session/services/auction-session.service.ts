import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AuctionSessionService {

  constructor(private httpClient: HttpClient) {
  }

  getAuctionSessions(): Observable<any> {
    return this.httpClient.get<any>(environment.endPointUrl + environment.auctionSession);
  }

  getAuctionSession(id:number):Observable<any>{
    return this.httpClient.get<any>(environment.endPointUrl+environment.auctionSession+"/id/"+id);
  }

  updateAuctionSession(id:number,data:any)
  {
    return this.httpClient.put(environment.endPointUrl+environment.auctionSession+'/id/'+id,data);
  }
}
