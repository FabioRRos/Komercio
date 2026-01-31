package shared

import (
	"strings"
	"time"
)

// ISO8601Time trata o formato "2026-01-27T18:30:00" comum no .NET
type ISO8601Time struct {
	time.Time
}

func (it *ISO8601Time) UnmarshalJSON(b []byte) error {
	s := strings.Trim(string(b), "\"")
	if s == "null" || s == "" {
		return nil
	}
	const layout = "2006-01-02T15:04:05"

	// Layout padrão do C# DateTime sem offset

	t, err := time.Parse(layout, s)
	if err != nil {
		return err
	}
	it.Time = t
	return nil
}

// Método útil para quando você precisar converter de volta para string no formato correto
func (it ISO8601Time) MarshalJSON() ([]byte, error) {
	const layout = "2006-01-02T15:04:05"
	return []byte(`"` + it.Time.Format(layout) + `z` + `"`), nil
}
