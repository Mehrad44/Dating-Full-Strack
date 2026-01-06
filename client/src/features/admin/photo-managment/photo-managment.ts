import { Component, inject, signal } from '@angular/core';
import { Photo } from '../../../types/member';
import { AdminService } from '../../../core/services/admin-service';

@Component({
  selector: 'app-photo-managment',
  imports: [],
  templateUrl: './photo-managment.html',
  styleUrl: './photo-managment.css',
})
export class PhotoManagment {
   photos = signal<Photo[]>([]);
  private adminService = inject(AdminService);

  ngOnInit(): void {
    this.getPhotosForApproval();
  }

  getPhotosForApproval() {
    this.adminService.getPhotosForApproval().subscribe({
      next: photos => this.photos.set(photos)
    });
  }

  approvePhoto(photoId: number) {
    this.adminService.approvePhoto(photoId).subscribe({
      next: () => {
        this.photos.update(photos =>
          photos.filter(x => x.id !== photoId)
        );
      }
    });
  }

  rejectPhoto(photoId: number) {
    this.adminService.rejectPhoto(photoId).subscribe({
      next: () => {
        this.photos.update(photos =>
          photos.filter(x => x.id !== photoId)
        );
      }
    });
  }
}
