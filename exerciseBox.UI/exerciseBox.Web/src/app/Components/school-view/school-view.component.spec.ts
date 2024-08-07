import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SchoolViewComponent } from './school-view.component';

describe('SchoolViewComponent', () => {
  let component: SchoolViewComponent;
  let fixture: ComponentFixture<SchoolViewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SchoolViewComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(SchoolViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
