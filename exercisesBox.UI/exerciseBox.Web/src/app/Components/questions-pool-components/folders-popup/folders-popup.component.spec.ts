import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FoldersPopupComponent } from './folders-popup.component';

describe('FoldersPopupComponent', () => {
  let component: FoldersPopupComponent;
  let fixture: ComponentFixture<FoldersPopupComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FoldersPopupComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(FoldersPopupComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
