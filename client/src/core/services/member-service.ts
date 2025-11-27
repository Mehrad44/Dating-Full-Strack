import { HttpClient } from '@angular/common/http';
import { inject, Injectable, signal } from '@angular/core';
import { environment } from '../../environments/environment';
import { EditableMember, Member, Photo } from '../../types/member';
import { single, tap } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class MemberService {
  private http = inject(HttpClient);

  private baseUrl = environment.apiUrl;

  editMode = signal(false);

  member = signal<Member | null>(null);

  getMembers(){
    return this.http.get<Member[]>(this.baseUrl+'Members' );
  }

  getMember(id : string){
    return this.http.get<Member>(this.baseUrl + 'Members/'+id ).pipe(
      tap(member => {
        this.member.set(member);
      }
      )
    )

  }

  getMemberPhotos(id : string){
    return this.http.get<Photo[]>(this.baseUrl + 'Members/'+  id + '/photos')
  }

  updateMember(member:EditableMember){
    return this.http.put(this.baseUrl +  'Members' , member);
  }

 

  
}
