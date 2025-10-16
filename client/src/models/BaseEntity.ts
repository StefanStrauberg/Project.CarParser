export interface BaseEntity {
  id: string; // Guid → string
  createdAt: Date; // DateTime → ISO string
  updatedAt?: Date | null; // DateTime? → optional + nullable
}
